using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace TH
{
    abstract class Entity: Collidable, NoiseMaker, Displayable, Movable
    {
        
        protected int hp;
        protected int shownHP;
        protected int currentHP;
        protected int mp;
        protected int shownMP;
        protected int currentMP;

        protected Point loc;
        protected int XVel;
        protected int YVel;
        protected int baseSpeed;

        protected Image img;
        protected Hitbox hitbox;
        protected Team currentTeam;

        public bool canCollideWithTeam = false;
        public bool canCollideWithEnemy = true;
        public bool canCollideWithFriendly = false;
        public bool canCollideWithHostile = true;
        public bool canCollideWithProjectile = false;
        public bool canCollideWithBoss = true;
        public bool canCollideWithMinion = true;
        
        public Image image
        {
            get { return img; }
            set { img = value; }
        }
        public Point currentLocation
        {
            get { return loc; }
            set { loc = value; }
        }
        public Point centerLocation
        {
            get { return new Point(loc.X + img.Width / 2, loc.Y - img.Height / 2); }
            set { loc = new Point(value.X - img.Width / 2, value.Y + img.Height / 2); }
        }

        /// <summary>
        /// Gets o Sets the entity's HP.
        /// </summary>
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        /// <summary>
        /// Gets or Sets the Entity's MP.
        /// </summary>
        public int MP
        {
            get { return mp; }
            set { value = mp; }
        }
        /// <summary>
        /// X coordinate of the upper left corner of the entity.
        /// </summary>
        public int X
        {
            get { return loc.X; }
            set { loc.X = value; }
        }
        /// <summary>
        /// Y coordinate of the upper left corner of the entity.
        /// </summary>
        public int Y
        {
            get { return loc.Y; }
            set { loc.Y = value; }
        }
        /// <summary>
        /// X coordinate of the center of the entity.
        /// </summary>
        public int centralXCoordinate
        {
            get { return loc.X + img.Width / 2; }
            set { loc.X = value - img.Width; }
        }
        /// <summary>
        /// Y coordinate of the center of the entity.
        /// </summary>
        public int centralYCoordinate
        {
            get { return loc.Y + img.Width / 2; }
            set { loc.Y = value - img.Width; }
        }
        /// <summary>
        /// Width of the entity.
        /// </summary>
        public int Width
        {
            get { return img.Width; }
        }
        /// <summary>
        /// Height of the entity.
        /// </summary>
        public int Height
        {
            get { return img.Height; }
        }
        /// <summary>
        /// Image of the entity.
        /// </summary>
        public Image imgage
        {
            get { return img; }
            set { img = value; }
        }
        /// <summary>
        /// Gets the hitbox of the entity.
        /// </summary>
        public Hitbox HitBox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }
        /// <summary>
        /// Gets or Sets the team of this entity.
        /// </summary>
        public Team TEAM
        {
            get { return currentTeam; }
            set { currentTeam = value; }
        }
        /// <summary>
        /// Constructs a new entity.
        /// Every entity will have a default Circle hitbox of size 10 right at the center of the entity.
        /// Hitboxes cannot be null. If you want an entity without a hitbox, make a Polyhitbox and 
        /// do not add anything to it.
        /// Hp is set to 1 and mp is set to 0 by default.
        /// Use the properties HP and MP to edit.
        /// </summary>
        /// <param name="w">Width of the entity</param>
        /// <param name="h">Height of the entity</param>
        /// <param name="x">(Optional)X coordinate of the upper left corner of the entity. Defaults to 0 if not set.</param>
        /// <param name="y">(Optional)Y coordinate of the upper left corner of the entity. Defaults to 0 if not set.</param>
        public Entity(Image img)
        {
            this.loc = new Point(0,0);
            hp = 1;
            mp = 0;
            baseSpeed = 10;
            this.img = img;
            hitbox = new CircleHitbox(this, img.Width / 2, img.Height / 2, 10);
            currentTeam = Team.NEUTRAL;
            hitbox.setHitboxColor(Color.Gray, Color.White);
        }
        public Entity(Image img, Point loc, Hitbox hb, int hp = 1, int mp = 0,int baseSpeed = 10, Team team = Team.NEUTRAL)
        {
            this.loc = loc;
            this.hp = hp;
            shownHP = hp;
            currentHP = hp;
            this.mp = mp;
            shownMP = mp;
            currentMP = mp;
            this.hitbox = hb;
            this.baseSpeed = baseSpeed;
            currentTeam = team;
            hb.setHitboxColor(Color.Gray, Color.White);
        }
        ~Entity()
        {

        }
        /// <summary>
        /// Checks for collision with another entity.
        /// Uses the hitbox of the entity to check collision.
        /// </summary>
        /// <param name="collide">Entity to collide with</param>
        /// <returns>True if they collide. False otherwise.</returns>
        public bool CheckCollision(Entity collide)
        {
            if (HitBox == null || collide.HitBox == null)
            {
                return false;
            }
            if (HitBox.CollideWith(collide.HitBox))
            {
                collide.HandleTheCollision();
                HandleTheCollision();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Handle its own collision not reflecting to any other entity.
        /// </summary>
        public abstract void HandleTheCollision();
        /// <summary>
        /// Sets the hitbox of the entity.
        /// </summary>
        /// <param name="h">The new Hitbox. Cannot be null.</param>
        public void setHitbox(Hitbox h)
        {
            if (h == null)
            {
                throw new ArgumentException("Hitbox cannot be null");
            }
            hitbox = h;
        }
        /// <summary>
        /// Sets the team of an entity. If the entity has not been added into a combat stage, it will just set the entity's team.
        /// If it was added already, it will adjust the combat stage's list of entities.
        /// </summary>
        /// <param name="t">The team</param>
        public void setTeam(Team t)
        {
            if (this == null)
            {
                throw new ArgumentException("how is it null?");
            }
            if (t == currentTeam)
            {

                return;
            }
            /*if (//currentStagePanel == null)
            {
                currentTeam = t;
                switch (t)
                {
                    case Team.ALLY:
                        HitBox.setHitboxColor(Color.Blue, Color.AliceBlue);
                        break;
                    case Team.ENEMY:
                        HitBox.setHitboxColor(Color.Red, Color.White);
                        break;
                    case Team.HOSTILE:
                        HitBox.setHitboxColor(Color.Red, Color.IndianRed);
                        break;
                    case Team.NEUTRAL:
                        HitBox.setHitboxColor(Color.Gray, Color.White);
                        break;
                    default:
                        throw new ArgumentException("What is that!?");
                }

                return;
            }*/
            switch (currentTeam)
            {
                case Team.ALLY:
                    //currentStage.AllyEntities.Remove(this);
                    break;
                case Team.ENEMY:
                    //currentStage.EnemyEntities.Remove(this);
                    break;
                case Team.HOSTILE:
                    //currentStage.HostileEntities.Remove(this);
                    break;
                case Team.NEUTRAL:
                    //currentStage.NeutralEntities.Remove(this);
                    break;
                default:
                    throw new ArgumentException("What is that!?");
            }

            switch (t)
            {
                case Team.ALLY:
                    //currentStage.AllyEntities.Add (this);
                    HitBox.setHitboxColor(Color.Blue, Color.AliceBlue);
                    break;
                case Team.ENEMY:
                    //currentStage.EnemyEntities.Add (this);
                    HitBox.setHitboxColor(Color.Red, Color.White);
                    break;
                case Team.HOSTILE:
                    //currentStage.HostileEntities.Add (this);
                    HitBox.setHitboxColor(Color.Red, Color.IndianRed);
                    break;
                case Team.NEUTRAL:
                    //currentStage.NeutralEntities.Add (this);
                    HitBox.setHitboxColor(Color.Gray, Color.White);
                    break;
                default:
                    throw new ArgumentException("What is that!?");
            }
        }
        /// <summary>
        /// the readonly list of all the sounds that the entity can play.
        /// </summary>
        private readonly List<Sound> effects = new List<Sound>();
        /// <summary>
        /// Returns a list of sound effects. 
        /// Should be overrided.
        /// </summary>
        /// <returns></returns>
        protected abstract List<Sound> getSoundEffects();
        /// <summary>
        /// plays the sound with the given soundeffect
        /// </summary>
        /// <param name="soundEffect">the sound effect to play</param>
        public void play(Sound soundEffect)
        {
            SoundPlayer.play(soundEffect);
        }
        /// <summary>
        /// palys the sound with the given ID
        /// ID is the index of the list of sounds
        /// </summary>
        /// <param name="soundEffectID">the ID of the sound effect to play</param>
        public void play(int soundEffectID)
        {
            SoundPlayer.play(effects[soundEffectID]);
        }
        public void draw()
        {
            Graphics g = Screen.g;
            g.DrawImage(img,loc);
        }
        public void draw(double Clockwise)
        {
            float w = img.Width, h = img.Height;
            float r = (float)Math.Sqrt((w * w) + (h * h));
            Bitmap returnBitmap = new Bitmap((int)(r), (int)(r));
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform(r / 2, r / 2);
            g.RotateTransform((float)Clockwise);
            g.TranslateTransform(-w / 2, -w / 2);
            g.DrawImage(img, new Point(0, 0));
            img = returnBitmap;
            returnBitmap.Dispose();
            g = Screen.g;
            g.DrawImage(img, centerLocation);
        }
        public void move()
        {
            loc.X += XVel;
            loc.Y += YVel;
        }
        public int xVel
        {
            get { return XVel; }
            set { XVel = value; }
        }
        public int yVel
        {
            get { return YVel; }
            set { YVel = value; }
        }
    }
}
