using System;
using SDL2;

namespace RayCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("Unable to initialize SDL. Error: {0}", SDL.SDL_GetError());
                return;
            }
            
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            var window = IntPtr.Zero;

            window = SDL.SDL_CreateWindow(
                "Title",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                1020,
                800,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            if (window == IntPtr.Zero)
            {
                Console.WriteLine("Unable to create a window. Error: {0}", SDL.SDL_GetError());
                return;
            }

            SDL.SDL_Event e;

            bool quit = false;

            while (!quit)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            switch (e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_q:
                                    quit = true;
                                    break;
                            }
                            
                            break;
                        
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                    }
                }
            }
            
            SDL.SDL_DestroyWindow(window);
            
            SDL.SDL_Quit();
        }
    }
}