const hoja = "Diciembre";
let turnos;

async function getTurnos() {
  let response;
  try {
    response = await gapi.client.sheets.spreadsheets.values.get({
      spreadsheetId: SPREADSHEET,
      range: hoja + "!A:G",
    });
  } catch (err) {
    document.getElementById("content").innerText = err.message;
    return;
  }
  const range = response.result;
  if (!range || !range.values || range.values.length == 0) {
    document.getElementById("content").innerText = "No values found.";
    return;
  }

  turnos = [];
  range.values.forEach((fila) => {
    if (isNaN(parseInt(fila[0])) || fila[5] !== undefined) return;
    const nuevoTurno = {
      id: fila[0],
      personal: fila[1],
      telefono: fila[2],
      dia: fila[3],
      mes: fila[4],
      fecha_terminado: fila[5],
      asistencia: fila[6]
    };
    turnos.push(nuevoTurno);
  });
}

async function editTurno(id, contenido) {
  const update = [
    contenido.id,
    contenido.personal,
    contenido.telefono,
    contenido.dia,
    contenido.mes,
    new Date().toLocaleString(),
    contenido.asistencia,
  ]
  const filaAEditar = parseInt(id)+1;
  response = await gapi.client.sheets.spreadsheets.values.update({
    spreadsheetId: SPREADSHEET,
    range: `${hoja}!A${filaAEditar}:G${filaAEditar}`,
    values: [update],
    valueInputOption:"USER_ENTERED"
  });
  return response;
}
