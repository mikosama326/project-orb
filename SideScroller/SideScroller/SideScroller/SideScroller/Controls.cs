using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SideScroller
{
    ///<summary>
    ///Abstract class to control the player by setting all the player states. (Can the abstract be changed?)
    ///</summary>
    abstract public class Controls
    {
        #region Fields

        //Physical states of the player using these controls
        public bool isWalkingLeft = false;
        public bool isWalkingRight = false;
        public bool isJumping = false;
        public bool isStill = true;
        public bool isFacingForward = false;

        #endregion

        #region Public Methods

        ///<summary>
        ///Resets the states
        ///</summary>
        public void resetState()
        {
            isWalkingLeft = false;
            isWalkingRight = false;
            isJumping = false;
            isStill = true;
            isFacingForward = false;
        }

        #endregion

        #region Overridden Methods

        abstract public void getState(KeyboardState pressedKeys);

        #endregion
    }

    public class KeyboardControls : Controls //Class to control the player using Keyboard
    {

        #region Public Methods
        ///<summary>
        ///Determines The state of the Player using keyboard controls
        ///</summary>
        /// <param name="pressedKeys">Indicates the pressed keys at time of update</param>
        override public void getState(KeyboardState pressedKeys)
        {
            //To revert states to defaults so that the next frame starts afresh
            resetState();

            if (pressedKeys.IsKeyDown(Keys.A) && !pressedKeys.IsKeyDown(Keys.D))
            {
                isWalkingLeft = true;
                isWalkingRight = false;
                isStill = false;
                isFacingForward = false;
            }

            else if (pressedKeys.IsKeyDown(Keys.D) && !pressedKeys.IsKeyDown(Keys.A))
            {
                isWalkingRight = true;
                isWalkingLeft = false;
                isStill = false;
                isFacingForward = false;
            }

            else// if (!pressedKeys.IsKeyDown(Keys.D) && !pressedKeys.IsKeyDown(Keys.A))
            {
                isStill = true;
                isWalkingLeft = false;
                isWalkingRight = false;
            }

            if (pressedKeys.IsKeyDown(Keys.W))
            {
                isJumping = true;
                isFacingForward = false;
            }

            if (isStill && pressedKeys.IsKeyDown(Keys.D) && pressedKeys.IsKeyDown(Keys.A) && !pressedKeys.IsKeyDown(Keys.W))
            {
                isFacingForward = true;
            }
        }

        #endregion
    }

    /*class OtherControls : Controls //Class meant to deal with (PS3) controller controls. Empty for now.
    {

    }*/

    /*Original plan had been to use Polymorphism and have a common Controls object used in the Player class.
     * Like: Controls playerState = new KeyboardControls();
     * This allows for an easy controller change.
     * Can it be done?
     */
}
