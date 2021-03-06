Projectile = function(game, x, y, assetName){

	Phaser.Sprite.call(this, game, x, y, assetName);

	// Physics body.
	this.game.physics.arcade.enable(this);

	// Add to the game.
	game.projectiles.add(this);
};

Projectile.prototype = Object.create(Phaser.Sprite.prototype);
Projectile.prototype.constructor = Projectile;

Projectile.prototype.update = function () {
	if(this.x > 800 || this.x < 0){
		this.kill();
	}
};