<?php

require 'Controller.php';

class Profile extends Controller
{
	public static function index()
	{
		$list = self::db('profiles');
		self::render('common/profiles', ['list' => $list]);

	}

	public static function page($id)
	{
		$list = self::db('profiles');
		if(!array_key_exists($id, $list)) {
			Flight::notFound();
			return;
		}
		self::render('common/profile', $list[$id]);
	}
}