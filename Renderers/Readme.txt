

This class is the shared class for renderers, available renderers will be listed in Renderers class and
all renderers should share the same setting defined in this library.

You can add renderer in any library or exe file you want, just define a class inherits IRenderer.

The Renderers class includes a method to find all renderers located in my nes folder, just call FindRenderers().
