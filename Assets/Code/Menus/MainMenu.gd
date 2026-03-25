extends Control

@onready var main_buttons: VBoxContainer = $MainButtons
@onready var options: Panel = $Options

# Called when the node enters the scene tree for the first time.
func _ready():
	main_buttons.visible = true
	options.visible = false


func _on_start_pressed():
	LevelTransition.change_scene_to("res://Levels/WorldLevels/WorldPartOne/Level1.tscn")
	pass

func _on_settings_pressed():
	print("Settings pressed")
	main_buttons.visible = false
	options.visible = true

func _on_exit_pressed():
	get_tree().quit()
	pass


func _on_back_options_pressed():
	_ready()
