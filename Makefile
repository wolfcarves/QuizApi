dev:
	dotnet watch --project QuizApi.WebApi/QuizApi.WebApi.csproj
migration:
	dotnet ef migrations add $(name) --startup-project ./QuizApi.WebApi --project ./QuizApi.Infrastructure --output-dir ./Migrations --namespace $(name)
update-database:
	dotnet ef database update --startup-project ./QuizApi.WebApi --project ./QuizApi.Infrastructure