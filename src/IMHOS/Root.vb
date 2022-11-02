﻿Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private textures As ITextures
    Private textureRegions As ITextureRegions
    Private sprites As ISprites
    Private instances As IEntities
    Private shipPosition As IWriteValueSource(Of (Single, Single))
    Private shipRotation As IWriteValueSource(Of Single)
    Private shipColor As IWriteValueSource(Of (Byte, Byte, Byte, Byte))
    Private hexSprite As IReadValueSource(Of ISprite)
    Private shipSprite As IWriteValueSource(Of ISprite)
    Sub New()
        graphics = New GraphicsDeviceManager(Me)
    End Sub
    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        Window.Title = "Interstellar Murder Hobos of SPLORR!!"
        graphics.PreferredBackBufferWidth = ScreenWidth
        graphics.PreferredBackBufferHeight = ScreenHeight
        graphics.ApplyChanges()
        Content.RootDirectory = "Content"
    End Sub
    Protected Overrides Sub LoadContent()
        MyBase.LoadContent()
        spriteBatch = New SpriteBatch(GraphicsDevice)
        textures = New Textures(GraphicsDevice, New Dictionary(Of Long, String) From
        {
            {Constants.Textures.Hex, "Content/hex.png"},
            {Constants.Textures.Ship, "Content/ship.png"}
        })
        textureRegions = New TextureRegions(textures, New Dictionary(Of Long, (Long, ((Integer, Integer), (Integer, Integer))?)) From
        {
            {Constants.TextureRegions.Hex, (Constants.Textures.Hex, Nothing)},
            {Constants.TextureRegions.Ship, (Constants.Textures.Ship, Nothing)}
        })
        sprites = New UI.Sprites(textureRegions, New Dictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) From
        {
            {Constants.Sprites.Hex, (Constants.TextureRegions.Hex, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)},
            {Constants.Sprites.Ship, (Constants.TextureRegions.Ship, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)}
        })
        hexSprite = New ReadOnlyValueSource(Of ISprite)(sprites.Read(Constants.Sprites.Hex))

        Dim plotter As IPlotter = New HexPlotter(48.0F, 64.0F)
        shipRotation = New ReadWriteValueSource(Of Single)(Math.PI * 3.0F / 3.0F)
        shipColor = New ReadWriteValueSource(Of (Byte, Byte, Byte, Byte))((0, 0, 255, 255))
        shipPosition = New ReadWriteValueSource(Of (Single, Single))((32.0F, 32.0F))
        shipSprite = New ReadWriteValueSource(Of ISprite)(sprites.Read(Constants.Sprites.Ship))
        instances = New Entities
        For x = 0L To 25L
            For y = 0L To 9L
                instances.Add(New Entity(
                              hexSprite,
                              New ReadOnlyValueSource(Of (Single, Single))((40.0F + plotter.PlotX(x, y), 56.0F + plotter.PlotY(x, y))),
                              New ReadOnlyValueSource(Of (Byte, Byte, Byte, Byte))((255, 255, 255, 255)),
                              New ReadOnlyValueSource(Of Single)(0.0F)))
            Next
        Next

        instances.Add(New Entity(shipSprite, shipPosition, shipColor, shipRotation))
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
        shipRotation.Write(shipRotation.Read() + 0.01F)

        Dim color = shipColor.Read
        shipColor.Write((CByte((color.Item1 + 1) And 255), CByte((color.Item2 + 254) And 255), color.Item3, color.Item4))

        Dim position = shipPosition.Read
        shipPosition.Write((position.Item1 + 1.0F, position.Item2))
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()
        instances.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
