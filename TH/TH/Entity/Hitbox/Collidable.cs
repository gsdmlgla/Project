using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    interface Collidable
    {
        /// <summary>
        /// Checks for collision with another entity.
        /// Uses the hitbox of the entity to check collision.
        /// </summary>
        /// <param name="collide">Entity to collide with</param>
        /// <returns>True if they collide. False otherwise.</returns>
        bool CheckCollision(Entity collide);


        /// <summary>
        /// Sets the hitbox of the entity.
        /// </summary>
        /// <param name="h">The new Hitbox. Cannot be null.</param>
        void setHitbox(Hitbox h);


        /// <summary>
        /// Sets the team of an entity. If the entity has not been added into a combat stage, it will just set the entity's team.
        /// If it was added already, it will adjust the combat stage's list of entities.
        /// </summary>
        /// <param name="t">The team</param>
        void setTeam(Team t);
    }
}
