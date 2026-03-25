extends CharacterBody2D


const move_speed = 2500.0

var current_look_dir = "right"

var can_slash: bool = true

@export var slash_time: float = 0.2
@export var sword_return_time: float = 0.5
@export var weapon_damage: float = 1.0

func _physics_process(delta: float) -> void:
	var input_vector = Vector2.ZERO
	input_vector.x = Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left")
	input_vector.y = Input.get_action_strength("ui_down") - Input.get_action_strength("ui_up")
	input_vector = input_vector.normalized()
	
	velocity = input_vector * move_speed * delta
	move_and_slide()

	if input_vector.x > 0:
		current_look_dir = "right"
	elif input_vector.x < 0:
		current_look_dir = "left"
	

	if current_look_dir == "right" and get_global_mouse_position().x < global_position.x:
		$Sprite2D/flip_anim.play("look_left")
		current_look_dir = "left"
	elif current_look_dir == "left" and get_global_mouse_position().x > global_position.x:
		$Sprite2D/flip_anim.play("look_right")
		current_look_dir = "right"	
	
	if get_global_mouse_position().y > global_position.y:
		$Sprite2D/sword.show_behind_parent = false
		$Sprite2D.frame = 1
	else:
		$Sprite2D/sword.show_behind_parent = true
		$Sprite2D.frame = 0
	
	if Input.is_action_just_pressed("attack") and can_slash:
		$Sprite2D/sword/AnimationPlayer.speed_scale = $Sprite2D/sword/AnimationPlayer.get_animation("slash").length / slash_time
		$Sprite2D/sword/AnimationPlayer.play("slash")
		can_slash = false

const sword_slash_preload = preload("res://Prefabs/Player/sword_slash.tscn")

func spawn_splash():
	var sword_slash_var = sword_slash_preload.instantiate()
	sword_slash_var.global_position = global_position
	sword_slash_var.get_node("Sprite/AnimationPlayer").speed_scale = sword_slash_var.get_node("Sprite/AnimationPlayer").get_animation("slash").length / slash_time
	sword_slash_var.get_node("Sprite").flip_v = false if get_global_mouse_position().y > global_position.y else true
	sword_slash_var.weapon_damage = weapon_damage
	get_parent().add_child(sword_slash_var)

func _on_animation_player_animation_finished(anim_name: StringName) -> void:
	if anim_name == "slash":
		$Sprite2D/sword/AnimationPlayer.speed_scale = $Sprite2D/sword/AnimationPlayer.get_animation("sword_return").length / sword_return_time
		$Sprite2D/sword/AnimationPlayer.play("sword_return")
	elif anim_name == "sword_return":
		can_slash = true
