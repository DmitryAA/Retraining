<?php
ini_set('display_errors', 1);


require '../vendor/autoload.php';
require '../app/Profile.php';

class envStore implements Techart\Frontend\EnvironmentStorageInterface
{

	public function getFromConfig($name)
	{
		if($name === 'env') {
			return 'dev';
		}
		var_dump($name);
		return null;
	}

	public function getFromRequest($name)
	{
		return null;
	}

	public function getFromSession($name)
	{
		return null;
	}

	public function setToSession($name, $value)
	{

	}

}

$env = new Techart\Frontend\Environment(new envStore());
$pathResolver = new Techart\Frontend\PathResolver('../frontend', ['twigCachePath' => '../twig']);
$frontend = new Techart\Frontend\Frontend($env, $pathResolver);


Flight::map('render', function ($block, $data) use ($frontend) {
	echo $frontend->templates()->renderBlock($block, $data);
});
Flight::view()->set('hScripts', $frontend->assets()->jsTag('index'));
Flight::view()->set('hStyles', $frontend->assets()->cssTag('index'));


Flight::route('/', array('Profile', 'index'));
Flight::route('/profile/@id/', array('Profile', 'page'));

Flight::start();
