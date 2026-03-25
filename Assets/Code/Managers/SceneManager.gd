extends Node

var scene_transition_screen = preload("res://Levels/WorldLevels/SceneTransitionScreen.tscn")

var scenes : Dictionary = { "Level1" : "res://Levels/WorldLevels/WorldPartOne/Level1.tscn",
					        "Level1A" : "res://Levels/WorldLevels/WorldPartOne/Level1A.tscn",
							"Level1B" : "res://Levels/WorldLevels/WorldPartOne/Level1B.tscn",
							"Level1C" : "res://Levels/WorldLevels/WorldPartTwo/Level1C.tscn",
						}

func transition_to_scene(level : String):
	var scene_path : String = scenes.get(level)

	if scene_path != null:
		var scene_transition_instance = scene_transition_screen.instantiate()
		get_tree().get_root().add_child(scene_transition_instance)
		await get_tree().create_timer(5.0).timeout
		get_tree().change_scene_to_file(scene_path)
		scene_transition_instance.queue_free()