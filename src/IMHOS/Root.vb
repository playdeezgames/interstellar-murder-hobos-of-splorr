Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private textures As ITextures
    Private textureRegions As TextureRegions
    Private sprites As UI.Sprites
    Private instances As Entities
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
        instances = New Entities
        instances.Add(New Entity(sprites.Read(Constants.Sprites.Hex), (32.0F, 32.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Constants.Sprites.Hex), (32.0F, 96.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Constants.Sprites.Hex), (80.0F, 64.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Constants.Sprites.Ship), (32.0F, 32.0F), (0, 0, 255, 255), Math.PI * 3.0F / 3.0F))
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        spriteBatch.Begin()
        instances.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
