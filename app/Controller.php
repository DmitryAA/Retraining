<?php

class Controller
{
	protected static function render($name, $data = [])
	{//Немного говнеца для бустрапа
		ob_start();
		Flight::render('blank/header', ['img' => 'img/logo.svg']);
		$header = ob_get_clean();
		ob_start();
		Flight::render($name, $data, 'content');
		$content = ob_get_clean();
		Flight::render('blank/layout', array(
			'footer' => '',
			'header' => $header,
			'content' => $content,
			'hScripts' => Flight::view()->get('hScripts'),
			'hStyles' => Flight::view()->get('hStyles'),
		));
	}

	protected static function db($name)
	{
		return require("db/$name.php");
	}
}