# SQL Lesson 1

All entries:
| №  | Id  | FirstName  | LastName   | Age | Gender | Address      |
|----|----|-----------|------------|-----|--------|--------------|
| 1  | 1  | Yevhenii  | Kravets    | 23  | M      | Chernihiv    |
| 2  | 2  | Maryna    | Pyatova    | 31  | F      | Kyiv         |
| 3  | 3  | Kolobok   | Dedovich   | 12  | M      | Selo         |
| 4  | 4  | Darth     | Vader      | 46  | M      | Tatooine     |
| 5  | 5  | name 1    | last name 1| 1   | M      | city 1       |
| 6  | 6  | name 2    | last name 2| 2   | M      | city 2       |
| 7  | 7  | name 3    | last name 3| 3   | M      | city 3       |
| 8  | 8  | name 4    | last name 4| 4   | M      | city 4       |
| 9  | 9  | name 5    | last name 5| 5   | M      | city 5       |
| 10 | 10 | name 6    | last name 6| 6   | M      | city 6       |
| 11 | 11 | Man       | Manovich   | 18  | M      | Manland      |
| 12 | 12 | Person    | Personov   | 16  | M      | Personland   |
| 13 | 13 | Persona   | Personova  | 20  | F      | Personland   |
| 14 | 14 | Personchik| Personov   | 17  | M      | Personland   |
| 15 | 15 | Personka  | Personova  | 19  | F      | Personland   |
| 16 | 16 | Wonam     | Womanova   | 18  | M      | Womanland    |
| 17 | 17 | Kadet     | Usypov     | 17  | M      | NULL         |
| 18 | 18 | Kinaret   | Mara       | 17  | M      | NULL         |
| 19 | 19 | Hermaeus  | Mora       | 18  | M      | NULL         |
| 20 | 20 | Molag     | Bal        | 18  | M      | NULL         |
| 21 | 21 | Sanquin   | Rose       | 19  | M      | NULL         |
| 22 | 22 | Daedric   | Sacred     | 19  | M      | NULL         |


## 1. Select All Males

```sql
SELECT * FROM Persons 
WHERE Gender = 'M';
```

Result:
| №  | Id  | FirstName  | LastName   | Age | Gender | Address    |
|----|----|-----------|------------|-----|--------|--------------|
| 1  | 1  | Yevhenii  | Kravets    | 23  | M      | Chernihiv    |
| 2  | 3  | Kolobok   | Dedovich   | 12  | M      | Selo         |
| 3  | 4  | Darth     | Vader      | 46  | M      | Tatooine     |
| 4  | 5  | name 1    | last name 1| 1   | M      | city 1       |
| 5  | 6  | name 2    | last name 2| 2   | M      | city 2       |
| 6  | 7  | name 3    | last name 3| 3   | M      | city 3       |
| 7  | 8  | name 4    | last name 4| 4   | M      | city 4       |
| 8  | 9  | name 5    | last name 5| 5   | M      | city 5       |
| 9  | 10 | name 6    | last name 6| 6   | M      | city 6       |
| 10 | 11 | Man       | Manovich   | 18  | M      | Manland      |
| 11 | 12 | Person    | Personov   | 16  | M      | Personland   |
| 12 | 14 | Personchik| Personov   | 17  | M      | Personland   |
| 13 | 16 | Wonam     | Womanova   | 18  | M      | Womanland    |
| 14 | 17 | Kadet     | Usypov     | 17  | M      |  NULL        |
| 15 | 18 | Kinaret   | Mara       | 17  | M      |  NULL        |
| 16 | 19 | Hermaeus  | Mora       | 18  | M      |  NULL        |
| 17 | 20 | Molag     | Bal        | 18  | M      |  NULL        |
| 18 | 21 | Sanquin   | Rose       | 19  | M      |  NULL        |
| 19 | 22 | Daedric   | Sacred     | 19  | M      |  NULL        |


---

## 2. Select all persons with age about 18

```sql
SELECT * FROM Persons 
WHERE Age >= 17 AND Age <= 19;
```

Result:
| №  | Id  | FirstName   | LastName    | Age | Gender | Address      |
|----|----|------------|-------------|-----|--------|--------------|
| 1  | 11 | Man        | Manovich    | 18  | M      | Manland      |
| 2  | 14 | Personchik | Personov    | 17  | M      | Personland   |
| 3  | 15 | Personka   | Personova   | 19  | F      | Personland   |
| 4  | 16 | Wonam      | Womanova    | 18  | M      | Womanland    |
| 5  | 17 | Kadet      | Usypov      | 17  | M      | NULL         |
| 6  | 18 | Kinaret    | Mara        | 17  | M      | NULL         |
| 7  | 19 | Hermaeus   | Mora        | 18  | M      | NULL         |
| 8  | 20 | Molag      | Bal         | 18  | M      | NULL         |
| 9  | 21 | Sanquin    | Rose        | 19  | M      | NULL         |
| 10 | 22 | Daedric    | Sacred      | 19  | M      | NULL         |

---

## 3. Select all persons without address

```sql
SELECT * FROM Persons
WHERE Address IS NULL;
```

Result:
| №  | Id | FirstName | LastName | Age | Gender | Address |
|----|----|-----------|----------|-----|--------|---------|
| 1  | 23 | Kadet     | Usypov   | 17  | M      | NULL    |
| 2  | 24 | Kinaret   | Mara     | 17  | M      | NULL    |
| 3  | 25 | Hermaeus  | Mora     | 18  | M      | NULL    |
| 4  | 26 | Molag     | Bal      | 18  | M      | NULL    |
| 5  | 27 | Sanquin   | Rose     | 19  | M      | NULL    |
| 6  | 28 | Daedric   | Sacred   | 19  | M      | NULL    |

---

## 4. Update age of all persons, add 1 year

```sql
UPDATE Persons
SET Age = Age + 1;

SELECT * FROM Persons;
```

Result:
| №  | Id | FirstName | LastName  | Age | Gender | Address     |
|----|----|-----------|-----------|-----|--------|-------------|
| 1  | 1  | Yevhenii  | Kravets   | 24  | M      | Chernihiv   |
| 2  | 2  | Maryna    | Pyatova   | 32  | F      | Kyiv        |
| 3  | 3  | Kolobok   | Dedovich  | 13  | M      | Selo        |
| 4  | 4  | Darth     | Vader     | 47  | M      | Tatooine    |
| 5  | 5  | name 1    | last name 1 | 2  | M      | city 1      |
| 6  | 6  | name 2    | last name 2 | 3  | M      | city 2      |
| 7  | 7  | name 3    | last name 3 | 4  | M      | city 3      |
| 8  | 8  | name 4    | last name 4 | 5  | M      | city 4      |
| 9  | 9  | name 5    | last name 5 | 6  | M      | city 5      |
| 10 | 10 | name 6    | last name 6 | 7  | M      | city 6      |
| 11 | 11 | Man       | Manovich  | 19  | M      | Manland     |
| 12 | 12 | Person    | Personov  | 17  | M      | Personland  |
| 13 | 13 | Persona   | Personova | 21  | F      | Personland  |
| 14 | 14 | Personchik| Personov  | 18  | M      | Personland  |
| 15 | 15 | Personka  | Personova | 20  | F      | Personland  |
| 16 | 16 | Wonam     | Womanova  | 19  | M      | Womanland   |
| 17 | 23 | Kadet     | Usypov    | 18  | M      | NULL        |
| 18 | 24 | Kinaret   | Mara      | 18  | M      | NULL        |
| 19 | 25 | Hermaeus  | Mora      | 19  | M      | NULL        |
| 20 | 26 | Molag     | Bal       | 19  | M      | NULL        |
| 21 | 27 | Sanquin   | Rose      | 20  | M      | NULL        |
| 22 | 28 | Daedric   | Sacred    | 20  | M      | NULL        |

---

## 5. Delete all rows without address

```sql
DELETE FROM Persons
WHERE Address IS NULL;

SELECT * FROM Persons;
```

Result:
| №  | Id | FirstName | LastName   | Age | Gender | Address     |
|----|----|-----------|------------|-----|--------|-------------|
| 1  | 1  | Yevhenii  | Kravets    | 24  | M      | Chernihiv   |
| 2  | 2  | Maryna    | Pyatova    | 32  | F      | Kyiv        |
| 3  | 3  | Kolobok   | Dedovich   | 13  | M      | Selo        |
| 4  | 4  | Darth     | Vader      | 47  | M      | Tatooine    |
| 5  | 5  | name 1    | last name 1| 2   | M      | city 1      |
| 6  | 6  | name 2    | last name 2| 3   | M      | city 2      |
| 7  | 7  | name 3    | last name 3| 4   | M      | city 3      |
| 8  | 8  | name 4    | last name 4| 5   | M      | city 4      |
| 9  | 9  | name 5    | last name 5| 6   | M      | city 5      |
| 10 | 10 | name 6    | last name 6| 7   | M      | city 6      |
| 11 | 11 | Man       | Manovich   | 19  | M      | Manland     |
| 12 | 12 | Person    | Personov   | 17  | M      | Personland  |
| 13 | 13 | Persona   | Personova  | 21  | F      | Personland  |
| 14 | 14 | Personchik| Personov   | 18  | M      | Personland  |
| 15 | 15 | Personka  | Personova  | 20  | F      | Personland  |
| 16 | 16 | Wonam     | Womanova   | 19  | M      | Womanland   |

---

## 6. Count number of rows in table

```sql
SELECT COUNT(*) AS CountRows FROM Persons;
```

Result:
| №  | CountRows |
|----|-----------|
| 1  | 16        |

---

## 7. Group persons by age and show how many persons with same age

```sql
SELECT Age, COUNT(*) AS CountPersons
FROM Persons
GROUP BY Age;
```

Result:
| №  | Age | CountPersons |
|----|-----|--------------|
| 1  | 2   | 1            |
| 2  | 3   | 1            |
| 3  | 4   | 1            |
| 4  | 5   | 1            |
| 5  | 6   | 1            |
| 6  | 7   | 1            |
| 7  | 13  | 1            |
| 8  | 17  | 1            |
| 9  | 18  | 1            |
| 10 | 19  | 2            |
| 11 | 20  | 1            |
| 12 | 21  | 1            |
| 13 | 24  | 1            |
| 14 | 32  | 1            |
| 15 | 47  | 1            |
