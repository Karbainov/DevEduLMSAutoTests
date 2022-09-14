Feature: FrontManagerCreatesAGroupAddsUsers

A short summary of the feature

@manager @teacher @tutor @student
Scenario: Front manager creates a group adds students and appoints a teacher and tutor
Given open the brouser and open DevEducation web page
#And registration users in service
#| FirstName | LastName   | Patronymic | BirthDate  | Password | RepeatPassword | Email            | PhoneNumber | Role    |
#| Gabriel   | Wilson     | string     | 15.04.1999 | 11345678 | 11345678       | wl@gmail.com     | 89514781247 | Student |
#| Isabella  | Abramson   | string     | 22.05.2001 | 11345578 | 11345578       | isi@gmail.com    | 89514551247 | Student |
#| Sophie    | Anderson   | string     | 18.01.1998 | 11344678 | 11344678       | sophie@gmail.com | 89511781247 | Student |
#| Maksim    | Karbainov  | string     | 18.05.1995 | 22345678 | 22345678       | maks@gmail.com   | 89521496531 | Teacher |
#| Anton     | Efremenkov | string     | 22.08.1988 | 22345698 | 22345698       | anton@gmail.com  | 89521477531 | Teacher |
#| Elisey    | Kakoyto    | string     | 07.10.1996 | 13345678 | 13345678       | elisey@gmail.com | 89518963148 | Tutor   |
And authorize users in service
| Email              | Password     |
| marina@example.com | marinamarina |
