﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShotsFired.Game.Server.Generators;
using ShotsFired.Game.Server.Models.Players;

namespace ShotsFired.Game.Server.Models
{
    /// <summary>
    /// A game containing players and the world they are playing in.
    /// </summary>
    public class GameInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Instance"/> class.
        /// </summary>
        /// <param name="worldId">The instance identifier.</param>
        public GameInstance(string instanceId, string hostPlayerId)
        {
            InstanceId    = instanceId;
            HostPlayerId  = hostPlayerId;
            Players       = new List<IPlayer>();
            World         = null;
            IsGameRunning = false;
        }

        /// <summary>
        /// Gets or sets the instance identifier.
        /// </summary>
        /// <value>
        /// The instance identifier.
        /// </value>
        public string InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the host player identifier.
        /// </summary>
        /// <value>
        /// The host player identifier.
        /// </value>
        public string HostPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the list of players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public List<IPlayer> Players { get; set; }

        /// <summary>
        /// Gets or sets the world.
        /// </summary>
        /// <value>
        /// The world.
        /// </value>
        public World World { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsGameRunning { get; set; }

        /// <summary>
        /// Begins the game.
        /// </summary>
        /// <param name="lobbyData">The lobby data.</param>
        public void BeginGame(Lobby lobbyData)
        {
            World = new World();
            World.Map = lobbyData.Map;
            World.Health = lobbyData.Health;
            World.Wind = lobbyData.Wind;
            World.TurnTimer = lobbyData.TurnTimer;
            World.Gravity = lobbyData.Gravity;
            IsGameRunning = true;

            // Generate a tank for each player.
            TankGenerator tankGenerator = new TankGenerator();
            Players.ForEach(player => player.Tank = tankGenerator.GenerateTank(player.TankSettings));
            Players.ForEach(player => player.IsInActiveGame = true);
        }

    }
}