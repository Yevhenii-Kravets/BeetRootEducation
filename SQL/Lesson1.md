# SQL Lesson 1

## Select All Males

```sql
SELECT * FROM Persons 
WHERE Gender = 'M';

Result:
| №  | Id | FirstName  | LastName   | Age | Gender | Address     |
|----|----|------------|------------|-----|--------|-------------|
| 1  | 1  | Yevhenii   | Kravets    | 23  | M      | Chernihiv   |
| 2  | 3  | Kolobok    | Dedovich   | 12  | M      | Selo        |
| 3  | 4  | Darth      | Vader      | 46  | M      | Tatooine    |
| 4  | 5  | name 1     | last name 1| 1   | M      | city 1      |
| 5  | 6  | name 2     | last name 2| 2   | M      | city 2      |
| 6  | 7  | name 3     | last name 3| 3   | M      | city 3      |
| 7  | 8  | name 4     | last name 4| 4   | M      | city 4      |
| 8  | 9  | name 5     | last name 5| 5   | M      | city 5      |
| 9  | 10 | name 6     | last name 6| 6   | M      | city 6      |
| 10 | 11 | Man        | Manovich   | 18  | M      | Manland     |
| 11 | 12 | Person     | Personov   | 16  | M      | Personland  |
| 12 | 14 | Personchik | Personov   | 17  | M      | Personland  |
| 13 | 16 | Wonam      | Womanova   | 18  | M      | Womanland   |
