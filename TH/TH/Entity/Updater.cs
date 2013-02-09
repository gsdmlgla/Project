using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    static class Updater
    {
        private static List<Collidable> toCheck = new List<Collidable>();
        private static List<Entity> allEntities = new List<Entity>();

        /// <summary>
        /// registers a class into the updater, an entity cannot be registered if it is already inside the updater
        /// </summary>
        /// <param name="e">the entity to register</param>
        /// <param name="check">whether or not to actively check the entity for collisions</param>
        /// <returns>true if the entity was registered, false otherwise</returns>
        public static bool register(Entity e, bool check = false)
        {
            if (check && !toCheck.Contains(e))
            {
                toCheck.Add(e);
                if (!allEntities.Contains(e))
                {
                    allEntities.Add(e);
                }
                return true;
            }
            if (!allEntities.Contains(e))
            {
                allEntities.Add(e);
                return true;
            }
            return false;
        }
        /// <summary>
        /// remove the entity from active collision checking
        /// </summary>
        /// <param name="e"> the entity to remove </param>
        /// <returns></returns>
        public static bool removeFromCheck(Entity e)
        {
            if (toCheck.Contains(e))
            {
                toCheck.Remove(e);
                return true;
            }
            return false;
        }

        /// <summary>
        /// removes an entity from the updater
        /// </summary>
        /// <param name="e">the entity to remove</param>
        /// <returns>true if removed, false otherwise</returns>
        public static bool unregister(Entity e)
        {
            if (allEntities.Contains(e))
            {
                if (toCheck.Contains(e))
                {
                    toCheck.Remove(e);
                }
                allEntities.Remove(e);
                return true;
            }
            return false;
        }
        /// <summary>
        /// empties out the active collision checking list
        /// </summary>
        /// <returns>a list with all the collidables that were bing actively checked</returns>
        public static List<Collidable> flushCollisionChecking()
        {
            List<Collidable> retList= null;
            if (toCheck.Any())
            {
                retList = toCheck;
                toCheck = new List<Collidable>();
            }
            return retList;
        }
        /// <summary>
        /// thread that updates and collides all the entities
        /// </summary>
        public static void update()
        {
            foreach(Collidable c in allEntities)
            {
                foreach (Entity e in allEntities)
                {
                    if (c != e)
                    {
                        c.CheckCollision(e);
                    }
                }
            }
            foreach (Entity e in allEntities)
            {
                e.move();
            }
        }
    }
}
