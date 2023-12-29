// import turnos from "./turnos.js";

const turnosContainer = document.getElementById("turnosContainer");
const detalleContainer = document.getElementById("detalleContainer");
let indiceSeleccionado;

const personalElement = document.getElementById("personal");
const diaElement = document.getElementById("dia");
const mesElement = document.getElementById("mes");
const asistenciaElement = document.getElementById("asistencia");
const marcarTerminadoElement = document.getElementById("finalizar");


function createTarjeta(turno,index){
  const nuevaTarjeta = document.createElement("div");
  nuevaTarjeta.classList = "tarjeta";
  nuevaTarjeta.innerHTML = `
    <h3>${turno.personal}</h3>
    <p>${turno.telefono}</p>
    <p>${turno.dia}</p>
    <p>${turno.mes}</p>
  `
  nuevaTarjeta.addEventListener("click", ()=> actualizarDetalle(index))
  turnosContainer.appendChild(nuevaTarjeta);
}

function actualizarTarjetas(){
  turnosContainer.innerHTML = "";
  turnos.forEach((turno,i) => {
    createTarjeta(turno,i);
  })
}

function actualizarDetalle(index){
  if(indiceSeleccionado !== undefined) turnosContainer.children[indiceSeleccionado].classList.toggle("seleccionado",false);
  personalElement.innerText = turnos[index].personal;
  diaElement.innerText = turnos[index].dia;
  mesElement.innerText = turnos[index].mes;
  detalleContainer.classList.toggle("escondido",false);
  indiceSeleccionado = index;
  turnosContainer.children[indiceSeleccionado].classList.toggle("seleccionado",true);
}

finalizar.addEventListener("click",()=> marcarTerminado(indiceSeleccionado))

async function marcarTerminado(i){
  const updateTurno = turnos[i];
  updateTurno.asistencia = asistenciaElement.value;
  const res = await editTurno(updateTurno.id,updateTurno);
  if(res.status === 200){
    turnos = turnos.filter(turno => turno.id !== updateTurno.id);
    indiceSeleccionado = 0;
    await actualizarTarjetas()
    detalleContainer.classList.toggle("escondido",true);
    asistenciaElement.value="";
  }
}

