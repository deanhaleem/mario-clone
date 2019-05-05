using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioBrosClone
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> keyDownCommands;
        private readonly Dictionary<Keys, ICommand> keyUpCommands;
        private readonly List<Keys> nonHoldableKeys;
        private Keys[] previouslyPressedKeys;

        public KeyboardController(params (Keys Key, ICommand KeyDownCommand, ICommand KeyUpCommand, bool CanBeHeld)[] args)
        {
            this.keyDownCommands = args.ToDictionary(x => x.Key, x => x.KeyDownCommand);
            this.keyUpCommands = args.ToDictionary(x => x.Key, x => x.KeyUpCommand);
            this.nonHoldableKeys = new List<Keys>();

            foreach (var (key, _, _, canBeHeld) in args)
            {
                if (!canBeHeld)
                {
                    this.nonHoldableKeys.Add(key);
                }
            }

            this.previouslyPressedKeys = Array.Empty<Keys>();
        }

        public void Update()
        {
            var currentlyPressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (var key in keyUpCommands.Keys)
            {
                if (!currentlyPressedKeys.Contains(key))
                {
                    keyUpCommands[key].Execute();
                }
            }

            foreach (var key in currentlyPressedKeys)
            {
                if (keyDownCommands.ContainsKey(key))
                {
                    if (!nonHoldableKeys.Contains(key) || !previouslyPressedKeys.Contains(key))
                    {
                        keyDownCommands[key].Execute();
                    }
                }
            }

            previouslyPressedKeys = currentlyPressedKeys;
        }
    }
}
