Imports Microsoft.Xna.Framework.Input

Public Class Root
    Inherits Game
    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private textures As ITextures
    Private textureRegions As ITextureRegions
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
        Dim plotter As IPlotter = New HexPlotter(Constants.Plotter.Width, Constants.Plotter.Height)
        stage = New Entities(Nothing, (Constants.Screen.Width / 2.0F, Constants.Screen.Height / 2.0F))

        Dim shipEntity = New ShipEntity(world.PlayerShip, stage, sprites.Read(Constants.Sprites.Ship), (0.0F, 0.0F), (0, 0, 255, 255), 0.0F)
        Dim gridEntity = New HexGridEntity(shipEntity, (0.0F, 0.0F), plotter, Constants.HexGrid.Size, sprites.Read(Constants.Sprites.Hex))
        shipEntity.Add(gridEntity)
        stage.Add(shipEntity)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        stage.Update(gameTime.ElapsedGameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        MyBase.Draw(gameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()

        stage.Draw(spriteBatch)

        spriteBatch.End()
    End Sub
End Class
