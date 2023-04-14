const card = document.querySelector('.card');
const container = document.querySelector('#container');


const title = document.querySelector(".title");
const description = document.querySelector(".info h3");
const sizes = document.querySelector(".sizes");

container.addEventListener("mousemove", (e) => {
    let xAxis = (window.innerWidth / 2 - e.pageX) / 12;
    let yAxis = (window.innerHeight / 2 - e.pageY) / 12;
    card.style.transform = `rotateY(${xAxis}deg) rotateX(${yAxis}deg)`;
  });
  

  container.addEventListener('mouseenter', e =>{
    card.style.trasition = 'none';

 
  title.style.transform = "translateZ(300px)";
  pika.style.transform = "translateZ(200px) rotateZ(-45deg)";
  });



  container.addEventListener('mouseleave', e => {
    card.style.trasition = 'all 0.5s ease';
    card.style.transform = `rotateY(0deg) rotateX(0deg)`;

   title.style.transform = "translateZ(0px)";

});