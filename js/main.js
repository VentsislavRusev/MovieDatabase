const burger = document.querySelector('.burger-icon');
const navbar = document.getElementById('nav-items');

burger.addEventListener('click', () => {
	"use strict";
	let nav = document.getElementById('custom-nav');
	nav.classList.toggle("nav-margin");
	navbar.classList.toggle("show-menu");
});

document.addEventListener('click', rippleEffect);

function rippleEffect(e) {
	"use strict";
	let xPos = e.clientX,
		yPos = e.clientY;

	let container = document.querySelector(".container");
	let circle = document.createElement("div");
	container.appendChild(circle);
	
	let diameter = Math.max(75, 75);
	circle.style.width = circle.style.height = diameter + "px";

	circle.classList.add("ripple");

	circle.style.left = (xPos - diameter / 2) + "px";
	circle.style.top = (yPos - diameter / 2) + "px";

	setTimeout(function () {
		container.removeChild(circle)
	}, 2000);
}

