![GeometrNote](https://img.shields.io/badge/GeometryNote-HyperCasual-orange)

# Task
Во время игровой сессии с верхней части экрана последовательно падают случайные объекты (например, простые кружочки, доллары, фрукты и тд), В центре экрана располагается выделенная для пользователя область. 
Когда объект достигает обозначенной области, пользователю необходимо успеть нажать на объект. Если пользователь успел вовремя нажать, объект плавно исчезает, пользователю начисляются очки с учетом коэффициента (см. далее). Если объект пересек выделенную область по центру игра заканчивается.
Скорость падения объектов повышается в зависимости от количества набранных очков или "уничтоженных" объектов.
Помимо игровой механики необходимо разработать главное меню, которое содержит:
1. Кнопку перехода в игровую сессию (play).
2. Рекордное количество очков пользователя (максимальное количество очков, которые пользователь набрал за все игровые сессии).
3. Кнопку перехода в окно настройки.
4. Подгружаемый из сети коэффициент множителя очков (это может быть любое числовое значение, например, текущий курс доллара, влажность воздуха в каком-то городе и тд. Можно использовать любое открытое и бесплатное API)
Окно настроек должно содержать:
Выбор внешнего вида падающих объектов (графика должна загружаться из AssetBundles)

# Software requirements
* Результат в виде Android приложения (.apk)
* Применение ООП
* Приветствуется архитектура, наличие компонентов
* Приветствуется применение принципов SOLID, KISS, DRY, YAGNI
* Плюсом будет использование Coroutine/Task/Generic

# Dependencies
* [Unity Editor 2020](https://unity3d.com/ru/unity/whats-new/2020.3.28)
