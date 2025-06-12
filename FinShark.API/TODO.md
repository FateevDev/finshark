1. Поправить отправку ошибку пользователю в UserController и других местах с 500
* 
* Добавьте `UseExceptionHandler()` в Program.cs, чтобы централизованно обрабатывать необработанные исключения.
* При необходимости выводить трассировку стека в Dev-среде используйте `DeveloperExceptionPageMiddleware` (по умолчанию уже подключён в режиме Development). `Program.cs`

2. Перенести добавление зависимостей в Program.cs в Configuration
