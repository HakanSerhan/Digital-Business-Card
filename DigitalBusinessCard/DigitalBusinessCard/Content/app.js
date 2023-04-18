const card = document.querySelector("#card");
const container = document.querySelector("#container");


container.addEventListener("mousemove", (e) => {
    let xAxis = (window.innerWidth / 2 - e.pageX) / 16;
    let yAxis = (window.innerHeight / 2 - e.pageY) / 16;
    card.style.transform = `rotateY(${xAxis}deg) rotateX(${yAxis}deg)`;
  });

