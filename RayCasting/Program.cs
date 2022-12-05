using System;
using SDL2;

namespace RayCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Window.Window window = new Window.Window(1020, 800);

            window.Launch();

            bool c = true;
            while (c)
            {
                while (window.GetEvent())
                {
                    switch (window.e.type)
                    {
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            switch (window.e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_q:
                                    c = false;
                                    break;
                            }
                            
                            break;
                        
                        case SDL.SDL_EventType.SDL_QUIT:
                            c = false;
                            break;
                    }
                    
                }
            }
            
            window.Quit();
        }
    }
}