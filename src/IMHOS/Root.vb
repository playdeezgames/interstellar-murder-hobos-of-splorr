Imports Microsoft.Xna.Framework.Input

Public Class Root
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
    Private shipSprite As IWriteValueSource(Of ISprite)
    Private gridOffset As IWriteValueSource(Of (Single, Single))
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
        gridOffset = New ReadWriteValueSource(Of (Single, Single))((-208.0F, 352.0F))
        Dim plotter As IPlotter = New HexPlotter(48.0F, 64.0F)
        shipRotation = New ReadWriteValueSource(Of Single)(Math.PI * 3.0F / 3.0F)
        shipColor = New ReadWriteValueSource(Of (Byte, Byte, Byte, Byte))((0, 0, 255, 255))
        shipPosition = New ReadWriteValueSource(Of (Single, Single))((32.0F, 32.0F))
        shipSprite = New ReadWriteValueSource(Of ISprite)(sprites.Read(Constants.Sprites.Ship))
        instances = New Entities
        instances.Add(New HexGridEntity(Nothing, gridOffset, plotter, 6L, sprites.Read(Constants.Sprites.Hex)))
        instances.Add(New Entity(Nothing, shipSprite, shipPosition, shipColor, shipRotation))
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        Dim keyboardState = Keyboard.GetState()
        Dim deltaX = If(keyboardState.IsKeyDown(Keys.Left), -1L, 0L) + If(keyboardState.IsKeyDown(Keys.Right), 1L, 0L)
        Dim deltaY = If(keyboardState.IsKeyDown(Keys.Up), -1L, 0L) + If(keyboardState.IsKeyDown(Keys.Down), 1L, 0L)
        Dim position = gridOffset.Read
        gridOffset.Write((position.Item1 + deltaX, position.Item2 + deltaY))
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()
        instances.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
