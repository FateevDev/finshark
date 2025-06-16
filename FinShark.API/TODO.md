1. Поправить отправку ошибку пользователю в UserController и других местах с 500
* 
* Добавьте `UseExceptionHandler()` в Program.cs, чтобы централизованно обрабатывать необработанные исключения.
* При необходимости выводить трассировку стека в Dev-среде используйте `DeveloperExceptionPageMiddleware` (по умолчанию уже подключён в режиме Development). `Program.cs`

2. Перенести добавление зависимостей в Program.cs в Configuration
3. Вынести добавление ошибок валидации в response в общий хелпер
```c#
    foreach (var error in createdUser.Errors)
    {
        ModelState.AddModelError(error.Code, error.Description);
    }

    return ValidationProblem(ModelState);
```
4. Сделать актуальное ридми со всеми особенностями проекта
~~5. Добавить правило, что email пользователя должен быть уникальным~~
6. Добавить стат анализаторы
   <PackageReference Include="Microsoft.CodeAnalysis.Analyzers" Version="3.3.4" />
   <PackageReference Include="Microsoft.CodeAnalysis.NetAnalyzers" Version="8.0.0" />
7. Добавить запуск стат анализаторов в makefile
