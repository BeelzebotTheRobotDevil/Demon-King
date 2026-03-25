extends Sprite2D
class_name PlayerCharacter

@onready var health_bar: ProgressBar = $"../CanvasLayer/HealthBar"



var health = 100

func _ready():
	health = 100
	health_bar.init_health(health)

func _set_health(value)	:
	_set_health(value)
	if health <= 0:
		_die()
	
	health_bar.health = health

func _die():
	print("Player Died")
