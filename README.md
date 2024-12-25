# Каталог фильмов

## Описание проекта

"Каталог фильмов" — это веб-приложение, разработанное на основе ASP.NET Core MVC. Оно предоставляет пользователю удобный интерфейс для управления коллекцией фильмов с возможностью добавления, редактирования, удаления и просмотра записей.

## Функциональность
- Просмотр списка фильмов с ключевыми характеристиками (название, жанр, дата выхода, бюджет).
- Добавление нового фильма через форму с валидацией данных.
- Редактирование информации о фильмах.
- Удаление фильмов с подтверждением действия.
- Обработка ошибок и отображение сообщений о необходимости корректного заполнения полей.

## Технологии
- **Язык программирования**: C#
- **Фреймворк**: ASP.NET Core MVC
- **Представления**: Razor Pages
- **Интерфейс**: HTML, CSS
- **Среда разработки**: Visual Studio Code
- **Система контроля версий**: Git

## Структура проекта
- **Controllers**: Контроллеры для обработки запросов и управления логикой приложения.
- **Models**: Модели данных, включая базовые и специализированные классы.
- **Views**: Представления для отображения данных пользователю (Index, Create, Edit, Delete).
- **Services**: Логика работы с данными и реализации бизнес-правил.
- **wwwroot**: Статические файлы (CSS, JS).
- **Program.cs**: Точка входа в приложение.

## Как запустить проект

1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/username/movie-catalog.git
   ```

2. Перейти в директорию проекта:
   ```bash
   cd movie-catalog
   ```

3. Открыть проект в Visual Studio Code.

4. Запустить приложение:
   ```bash
   dotnet run
   ```

5. Открыть браузер и перейти по адресу:
   ```
   http://localhost:5000
   ```

## Пример использования
- **Добавление фильма**: Заполните форму и сохраните данные.
- **Редактирование фильма**: Выберите фильм из списка и внесите изменения.
- **Удаление фильма**: Подтвердите удаление выбранного фильма.
