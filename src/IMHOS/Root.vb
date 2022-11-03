﻿Imports Microsoft.Xna.Framework.Input

Public Class Root
    Inherits Game
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private textures As ITextures
    Private textureRegions As ITextureRegions
    Private sprites As ISprites
    Private instances As IEntities
    Private shipPosition As (Single, Single)
    Private shipRotation As IWriteValueSource(Of Single)
    Private shipColor As IWriteValueSource(Of (Byte, Byte, Byte, Byte))
    Private shipSprite As IWriteValueSource(Of ISprite)
    Private gridOffset As (Single, Single)
    Sub New()
        graphics = New GraphicsDeviceManager(Me)
    End Sub
    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        Window.Title = "Interstellar Murder Hobos of SPLORR!!"
        graphics.PreferredBackBufferWidth = Constants.Screen.Width
        graphics.PreferredBackBufferHeight = Constants.Screen.Height
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
        gridOffset = (0.0F, 0.0F)
        Dim plotter As IPlotter = New HexPlotter(Constants.Plotter.Width, Constants.Plotter.Height)
        shipRotation = New ReadWriteValueSource(Of Single)(0.0F)
        shipColor = New ReadWriteValueSource(Of (Byte, Byte, Byte, Byte))((0, 0, 255, 255))
        shipPosition = (0.0F, 0.0F)
        shipSprite = New ReadWriteValueSource(Of ISprite)(sprites.Read(Constants.Sprites.Ship))
        instances = New Entities
        Dim gridEntity = New HexGridEntity(Nothing, gridOffset, plotter, Constants.HexGrid.Size, sprites.Read(Constants.Sprites.Hex))
        instances.Add(gridEntity)

        Dim shipEntity = New Entity(gridEntity.Hex(Constants.HexGrid.Size - 1L, Constants.HexGrid.Size - 1L), shipSprite, shipPosition, shipColor, shipRotation)
        instances.Add(shipEntity)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)

        'instances.Update(gameTime.ElapsedGameTime)

    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()

        instances.Draw(spriteBatch)

        spriteBatch.End()
    End Sub
End Class
