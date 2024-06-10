# Blackjack

Игра "блэкджэк" на WinForm C# с использование односвязного списка.
Правила игры могут отличаться от настоящих, ~~тк за основу взята версия из gta online.~~

## Требования к работе

Для колоды и рук игрока и дилера необходимо использовать структуру данных СТЭК (односвязный список).

Колода на 52 карты, создаётся один раз, а карты перемещаются из колоды в руки и обратно, не копируются, а именно перемещаются.

* Реализовать структуры для стэка и его элементов. Элементы - это карты с мастью, значением и количеством очков.
* Реализовать функции работы со стеком:
  - добавление элемента в начало
  - удаление с начала (с возвращением элемента)
  - добавление по указанному индексу (перед элементом)
  - удаление по указанному индексу (с возвращением элемента)
* Реализовать процесс создания колоды и перемешивания колоды (много раз берём карту и втыкаем в стэк колоды)
* Реализовать структуру игрока (дилер и игрок - переменные этого типа), у игрока есть рука, текущие очки и всё, что потребуется для удобства.
* Реализовать вывод игры (карты на руках у игроков в стэках)
* Реализовать процесс взятия карты из колоды, проверку суммы и т.д.
* Определение победителя и возврат карт в колоду, перемешивание колоды перед следующей игрой.
* Колода создается только при запуске программы.
* Сохранение ходов разных игр в файл.

## Демонстрация работы
![image](https://github.com/kiper01/blackjack/assets/122391140/6fe354fc-97f0-41fd-bcc9-2625976f8b03)
![image](https://github.com/kiper01/blackjack/assets/122391140/1da5116b-57fe-470e-b493-1aa8fe4a10b1)
![image](https://github.com/kiper01/blackjack/assets/122391140/61805659-2783-44ad-ab8f-b18ae6320e29)
