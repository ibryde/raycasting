using System;
using SDL2;

namespace Window;

public class Window
{
    protected IntPtr window;
    protected int height;
    protected int width;

    public SDL.SDL_Event e;
    
    public Window(int width, int height)
    {
        window = IntPtr.Zero;
        this.width = width;
        this.height = height;
    }

    public bool Launch()
    {
        if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
        {
            Console.WriteLine("Unable to initialize SDL. Error: {0}", SDL.SDL_GetError());
            return false;
        }

        window = SDL.SDL_CreateWindow(
            "Title",
            SDL.SDL_WINDOWPOS_CENTERED,
            SDL.SDL_WINDOWPOS_CENTERED,
            width,
            height,
            SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
        );

        if (window == IntPtr.Zero)
        {
            Console.WriteLine("Unable to create a window. Error: {0}", SDL.SDL_GetError());
            return false;
        }

        return true;
    }

    public void Quit()
    {
        SDL.SDL_DestroyWindow(window);
        SDL.SDL_Quit();
    }
    
    public bool GetEvent()
    {
        if (SDL.SDL_PollEvent(out e) == 0)
            return false;

        return true;
    }
}