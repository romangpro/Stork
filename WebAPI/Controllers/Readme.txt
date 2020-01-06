1. WebAPI exposes contract to consumers - must be "stable"
2. So we use versioning (ie v1), and the inputs and outputs should not be domain entities: to decouple changes, and customize the info presented.
3. For Security, the id in Controller is lookup in virtual table to entity real id.
4. Solution, ends up having 3-4 models.
	ViewModel (UI) <=> DTO (Controller) <=> Entity (Domain) <=> Dao (Persistence)