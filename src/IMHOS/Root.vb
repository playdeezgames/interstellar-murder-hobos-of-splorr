Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private textures As ITextures
    Private textureRegions As TextureRegions
    Private sprites As Sprites
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
        sprites = New Sprites(textureRegions)
        instances = New Entities
        instances.Add(New Entity(sprites.Read(Sprites.SpriteHex), (32.0F, 32.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Sprites.SpriteHex), (32.0F, 96.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Sprites.SpriteHex), (80.0F, 64.0F), (255, 255, 255, 255), 0))
        instances.Add(New Entity(sprites.Read(Sprites.SpriteShip), (32.0F, 32.0F), (0, 0, 255, 255), Math.PI * 3.0F / 3.0F))
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        spriteBatch.Begin()
        sprites.Read(Sprites.SpriteHex).Draw(spriteBatch, (32.0F, 32.0F), (255, 255, 255, 255), 0)
        instances.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
