
var employeeName = document.getElementById("Emp_SSN")
var projectName = document.getElementById("Proj_Id")
var projectArea = document.getElementById("projectarea")


employeeName.addEventListener("change", async () => {
    var project = await fetch("http://localhost:5154/Project/EditEmpProj_emp/" + employeeName.value)
    projectlist = await project.text();
    projectArea.innerHTML = projectlist;
})