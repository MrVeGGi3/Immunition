extends Control
@onready var loading_animation = $AnimatedSprite2D

var menu_scene = "res://scenes/HUD/menu.tscn"


func _ready():
	loading_animation.play("animation")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_timer_timeout():
	get_tree().change_scene_to_file(menu_scene)
