Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private shipSpriteInstance As SpriteInstance
    Private spriteBatch As SpriteBatch
    Private sprites As Sprites
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
        Textures.Load(GraphicsDevice)
        TextureRegions.Load()
        sprites = New Sprites
        shipSpriteInstance = New SpriteInstance(sprites.Read(Sprites.SpriteShip), New Vector2(32, 32), Color.Blue, Math.PI / 3)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        spriteBatch.Begin()
        sprites.Read(Sprites.SpriteHex).Draw(spriteBatch, New Vector2(32, 32), Color.White, 0)
        shipSpriteInstance.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
