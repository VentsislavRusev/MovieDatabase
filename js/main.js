const burger = document.querySelector('.burger-icon');
const navbar = document.getElementById('nav-items');

burger.addEventListener('click', () => {
	"use strict";
	let nav = document.getElementById('custom-nav');
	nav.classList.toggle("nav-margin");
	navbar.classList.toggle("show-menu");
});
