Public Class Root
    Inherits Game
    Const ScreenWidth = 1280
    Const ScreenHeight = 720
    Private ReadOnly graphics As GraphicsDeviceManager
    Private hexTexture As Texture2D
    Private shipTexture As Texture2D
    Private shipSprite As Sprite
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
        Using stream As New FileStream("Content/hex.png", FileMode.Open)
            hexTexture = Texture2D.FromStream(GraphicsDevice, stream)
        End Using
        Using stream As New FileStream("Content/ship.png", FileMode.Open)
            shipTexture = Texture2D.FromStream(GraphicsDevice, stream)
        End Using
        shipSprite = New Sprite(shipTexture, Nothing, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        spriteBatch.Begin()
        spriteBatch.Draw(hexTexture, New Vector2(0, 0), Color.White)
        shipSprite.Draw(spriteBatch, New Vector2(32, 32), Color.Blue, Math.PI / 3)
        spriteBatch.End()
    End Sub
End Class
