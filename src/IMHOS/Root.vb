Imports Microsoft.Xna.Framework.Input

Public Class Root
    Inherits Game
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private sprites As ISprites
    Private stage As IEntity
    Private world As IWorld = New World
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
        sprites = New Sprites(
            New TextureRegions(
                New Textures(
                    GraphicsDevice,
                    Constants.Textures.Source),
                Constants.TextureRegions.Source),
            Constants.Sprites.Source)
        stage = New Entities(Nothing, (Constants.Screen.Width / 2.0F, Constants.Screen.Height / 2.0F))

        Dim shipEntity = New ShipEntity(world.PlayerShip, stage, sprites.Read(Constants.Sprites.Ship), (0.0F, 0.0F), (0, 0, 255, 255), 0.0F)
        stage.Add(shipEntity)
    End Sub
    Private oldKeyboardState As New KeyboardState
    Private keyboardState As New KeyboardState
    Private pressedKeys As New HashSet(Of Keys)
    Private keyHandlers As New Dictionary(Of Keys, Action(Of IWorld)) From
        {
            {Keys.Left, Sub(world)
                            world.PlayerShip.Direction -= 1L
                        End Sub},
            {Keys.Right, Sub(world)
                             world.PlayerShip.Direction += 1L
                         End Sub}
        }
    Protected Overrides Sub Update(gameTime As GameTime)
        stage.Update(gameTime.ElapsedGameTime)
        UpdatePressedKeys()
        HandlePressedKeys()
    End Sub

    Private Sub HandlePressedKeys()
        For Each pressedKey In pressedKeys
            If keyHandlers.ContainsKey(pressedKey) Then
                keyHandlers(pressedKey)(world)
            End If
        Next
    End Sub

    Private Sub UpdatePressedKeys()
        oldKeyboardState = keyboardState
        keyboardState = Keyboard.GetState()
        pressedKeys = New HashSet(Of Keys)(
            keyboardState.GetPressedKeys().
            Where(Function(x) oldKeyboardState.IsKeyUp(x)))
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()

        stage.Draw(spriteBatch)

        spriteBatch.End()
    End Sub
End Class
