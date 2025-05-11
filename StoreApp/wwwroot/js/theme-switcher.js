document.addEventListener('DOMContentLoaded', () => {
    const toggleSwitch = document.querySelector('.theme-switch input[type="checkbox"]');
    const switchLabel = document.querySelector('.switch-label');
    

    const currentTheme = localStorage.getItem('theme') || 'light';
    
    if (currentTheme) {
        document.documentElement.setAttribute('data-theme', currentTheme);
        
        if (currentTheme === 'dark') {
            toggleSwitch.checked = true;
            switchLabel.textContent = 'Dark Mode';
        } else {
            switchLabel.textContent = 'Light Mode';
        }
    }
    
 
    toggleSwitch.addEventListener('change', switchTheme);
    
    function switchTheme(e) {
        if (e.target.checked) {
            document.documentElement.setAttribute('data-theme', 'dark');
            localStorage.setItem('theme', 'dark');
            switchLabel.textContent = 'Dark Mode';
        } else {
            document.documentElement.setAttribute('data-theme', 'light');
            localStorage.setItem('theme', 'light');
            switchLabel.textContent = 'Light Mode';
        }
    }
});