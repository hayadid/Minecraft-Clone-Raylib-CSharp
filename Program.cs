using System.Numerics;
using Raylib_cs;

public static class Program
{
    public static void Main(String[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

        Raylib.SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
                                               //--------------------------------------------------------------------------------------

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D();
        camera.Position = new Vector3(10.0f, 10.0f, 10.0f); // Camera position
        camera.Target = Vector3.Zero;                        // Camera looking at point
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.FovY = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraProjection.Perspective;   // Camera projection type

        Vector3 cubePosition = Vector3.Zero;

        Raylib.DisableCursor();                    // Limit cursor to relative movement inside the window

        Raylib.SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
                                                   //--------------------------------------------------------------------------------------

        // Main game loop
        while (!Raylib.WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            Raylib.UpdateCamera(ref camera, CameraMode.Free);

            if (Raylib.IsKeyPressed(KeyboardKey.Z)) camera.Target = Vector3.Zero;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RayWhite);

            Raylib.BeginMode3D(camera);

            Raylib.DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.Red);
            Raylib.DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.Maroon);

            Raylib.DrawGrid(10, 1.0f);

            Raylib.EndMode3D();

            Raylib.DrawRectangle(10, 10, 320, 93, Raylib.Fade(Color.SkyBlue, 0.5f));
            Raylib.DrawRectangleLines(10, 10, 320, 93, Color.Blue);

            Raylib.DrawText("Free camera default controls:", 20, 20, 10, Color.Black);
            Raylib.DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, Color.DarkGray);
            Raylib.DrawText("- Mouse Wheel Pressed to Pan", 40, 60, 10, Color.DarkGray);
            Raylib.DrawText("- Z to zoom to (0, 0, 0)", 40, 80, 10, Color.DarkGray);

            Raylib.EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        Raylib.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------
    }
}