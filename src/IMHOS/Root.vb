Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private shipSprite As Sprite
    Private shipSpriteInstance As SpriteInstance
    Private spriteBatch As SpriteBatch
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
        shipSprite = New Sprite(Textures.Read(TextureShip), Nothing, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)
        shipSpriteInstance = New SpriteInstance(shipSprite, New Vector2(32, 32), Color.Blue, Math.PI / 3)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        spriteBatch.Begin()
        spriteBatch.Draw(Textures.Read(TextureHex), New Vector2(0, 0), Color.White)
        shipSpriteInstance.Draw(spriteBatch)
        spriteBatch.End()
    End Sub
End Class
