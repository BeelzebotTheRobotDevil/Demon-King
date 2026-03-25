class_name Player

extends CharacterBody2D

@onready var state_machine: StateMachine = $StateMachine
@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D

func _ready(): state_machine._init()

func _process(delta): state_machine._process_frame(delta)

func _physics_process(delta): state_machine._process_physics(delta)

func _input(event): state_machine._process_input(event)
	
var can_slash:bool = true

@export var slash_time: float = 0.2
@export var sword_return_time: float = 0.5
@export var weapon_damage: float = 1.0

func spawn_slash():
  pass