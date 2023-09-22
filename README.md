Цей метод працюватиме лише у вас, якщо у вас є статична глобальна IP-адреса. Це можна дізнатися у вашого постачальника.

Нам потрібно для сервера:

OVPN сервер. Я використовував PIVPN. Встановив на Raspberry Pi. Інструкція - (http://kamilslab.com/2017/01/22/how-to-turn-your-raspberry-pi-into-a-home-vpn-server-using-pivpn/). Використовуйте всі стандартні параметри (не змінюйте порт. Повинен бути 1194).
OpenVPN Client File - в інструкції вказано, як його створити (розділ Create your OpenVPN Client File).
Для клієнта:

OpenVPN Клієнт для Windows - завантажте (https://swupdate.openvpn.org/community/releases/openvpn-install-2.4.7-I607-Win10.exe)
XboxTurnOn - завантажте (https://github.com/romamakar/XboxTurnOn/releases/download/1.1/Release.zip)
Xbox програма для Windows 10
Інструкція:

Для підключення Xbox до роутера (найкраще через LAN кабель):

На Xbox зайдіть в Система > Настройки > Включення і запуск. Режим живлення та встановіть Режим миттєвого запуску.
Запишіть на папері Ідентифікатор пристрою Xbox Live. Його можна знайти в Система > Настройки > Система > Інформація про консоль.
Для сервера:

Підключіть Raspberry Pi до роутера (найкраще через LAN кабель).
Створіть сервер (пункти 1 і 2).
Скопіюйте файл OpenVPN Client File (він знаходиться в home/pi/ovpns) на ваш клієнтський комп'ютер.
Зайдіть в налаштування роутера і встановіть переспрямування порту 1194 вашого Raspberry Pi та Xbox. У мене роутер TP-Link. Потрібно зайти на сторінку роутера - Перенаправлення - Віртуальні сервери - Додати. У Порту сервісу введіть 1194, у IP-адресу - локальний адреса Raspberry Pi (можна дізнатися в DHCP - Список клієнтів DHCP або в налаштуваннях мережі Raspberry Pi) і натисніть зберегти.
Потім додайте перенаправлення для Xbox - Перенаправлення - Віртуальні сервери - Додати. У Порту сервісу введіть 1-1193, у IP-адресу - локальний адреса Xbox (можна дізнатися в DHCP - Список клієнтів DHCP або в налаштуваннях мережі Xbox) і натисніть зберегти.
Для клієнта:

Встановіть всі програми з пунктів 3, 4, 5.

Скопіюйте OpenVPN Client File в папку C:\Program Files\OpenVPN\config.

У треї знайдіть OpenVPN GUI і натисніть праву клавішу миші - Підключити. Якщо буде запитувати IP-адресу - введіть свій глобальний статичний адрес. Якщо буде запитувати логін/пароль - використовуйте той, який ви вказували при створенні OpenVPN Client File (п. 2). Повинно успішно підключитися.

Запустіть програму XboxTurnOn.Winforms.exe (п. 4) і введіть локальну IP-адресу консолі в поле IP. У поле XboxLiveId введіть Ідентифікатор пристрою Xbox Live, який ви записали на папері, і натисніть Turn on.

Запустіть Xbox app (п. 5), увійдіть під своїм мікрософтським обліковим записом і виберіть пункт Підключення - Додати пристрій і тут введіть локальну IP-адресу консолі. Тепер все повинно працювати.

