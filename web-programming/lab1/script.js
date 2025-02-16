// Функция для переключения отображения меню
function toggleMenu() {
    const menu = document.getElementById("support-menu");
    
    // Если меню скрыто, показываем его, если видно - скрываем
    if (menu.style.display === "none" || menu.style.display === "") {
        menu.style.display = "block";
    } else {
        menu.style.display = "none";
    }
}
