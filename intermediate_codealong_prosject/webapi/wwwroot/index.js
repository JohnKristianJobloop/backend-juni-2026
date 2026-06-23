const form = document.getElementById("repairForm");
const list = document.getElementById("repairList");

async function loadRepairs() {
  const res = await fetch("/Repair");
  const repairs = await res.json();
  list.innerHTML = "";
  for (const r of repairs) {
    const li = document.createElement("li");
    li.textContent = `${r.customerName} — ${r.carModel} (${r.repairType})`;
    list.appendChild(li);
  }
}
form.addEventListener("submit", async (e) => {
  e.preventDefault();
  const dto = {
    customerName: form.customerName.value,
    carModel: form.carModel.value,
    repairType: form.repairType.value
  };
  await fetch("/Repair", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(dto)
  });
  form.reset();
  loadRepairs();
});
loadRepairs();