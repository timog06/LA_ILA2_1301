# Projekt-Dokumentation

### Gruppe Potski: Pascal Oestrich, Timo Goedertier

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
|15.09.2023| 0.0.1 | Das Projekt wurde in Visual Studio erstellt.                |
|15.09.2023| 0.0.2 | Das Programm hat die Eingabe Felder. (Felder funktionieren, werden aber noch nicht gespeichert) |
|22.09.2023| 0.0.3 | Wir haben am Programm weiter gearbeitet und es funkioniert jetzt alles ausser der Bearbeiten Modus und die Datenbank.|
|29.09.2023| 0.1.0 | Wir haben die Datenbanken hinzugefügt und mit dem Programm verbunden.|
|27.10.2023| 0.1.1 | Wir haben am Programm weiter gearbeitet und das archivieren funkioniert fast.|
|03.11.2023| 1.0.0 | Das Programm ist fertig programmiert und bereit für die Abgabe.|

## 1 Informieren

### 1.1 Ihr Projekt

Ein GUI um Hausaufgaben und Prüfungen, in einer Datenbank zu speichern und abzurufen.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ  | Beschreibung                       |
| ---- | --------------- | ---- | ---------------------------------- |
| 1    |Muss|Funktionalität| Als ein User möchte ich Hausaufgaben einschreiben können.|
| 2    |Muss|Funktionalität| Als ein User möchte ich Prüfungen einschreiben können.|
| 3    |Muss|Funktionalität| Als ein Developer möchte ich, dass die Daten in einer SQL-Datenbank gespeichert werden.|
| 4    |Muss|Funktionalität| Als ein User möchte ich eine Liste haben, die mir alle Hausaufgaben und Prfüungen anzeigt.|
| 5    |Muss|Qualität      | Als ein User möchte ich, dass das UI schön aussieht.|
| 6    |Muss|Rand          | Als ein User möchte ich, dass abgeschlossene Hausaufgaben/Prüfungen archiviert werden können.|
| 7    |Muss|Funktionalität| Als ein Developer möchte ich, dass das Program in WPF gemacht wird.|

### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1  |Program wurde gestartet|Nach dem eintragen von Daten wird der [Hausaufgaben einschreiben] gedrückt.|Die Daten werden für Hausaufgaben gespeichert.|
| 2.1  |Program wurde gestartet|Nach dem eintragen von Daten wird der [Prüfungen einschreiben] gedrückt.|Die Daten werden für Prüfungen gespeichert.|
| 3.1  |Program wurde gestartet|Daten werden eingeschrieben.|Die eingegebenen Daten werden in den vorgesehenen Datenbanken gespeichert.|
| 4.1  |Program wurde gestartet|[Liste anzeigen] wird gedrückt.|Die Liste geht in einem neuen Fenster auf|
| 5.1  |Program wurde gestartet|Das Böxchen wird angeclickt und ein Häckchen erscheint.|Dieser Eintrag wird 'archiviert' (in eine andere Datenbank verschoben).|

### 1.4 Diagramme

![image](https://github.com/timog06/LA_ILA2_1301/assets/110891995/3cd4347c-7b68-4fcb-aebb-253f57eb2a94)

## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A  |29.09.2023|Pascal Oestrich|Das Programm kann Hausaufgaben einschreiben.| 30' |
| 2.A  |29.09.2023|Pascal Oestrich|Das Programm kann Prüfungen einschreiben.| 30' |
| 3.A  |27.10.2023|Timo Goedertier|Das Programm speichert Eingaben in Datenbanken.| 30' |
| 4.A  |27.10.2023|Timo Goedertier|Das Programm hat eine Liste mit allen Eingaben| 15' |
| 5.A  |03.11.2023|Pascal Oestrich|Das 'Main' GUI sieht gut aus.| 15' |
| 5.B  |03.11.2023|Pascal Oestrich|Das 'Liste' GUI sieht gut aus.| 15' |
| 6.A  |03.11.2023|Timo Goedertier|Eingaben haben ein Böxchen, welches man anclicken kann.| 60' |
| 6.B  |03.11.2023|Timo Goedertier|Eingaben können durch das clicken der Böxchen archiviert werden.| 120' |
| 7.A  |03.11.2023|Pascal Oestrich/Timo Goedertier|Das Programm wird mit WPF gemacht.| - |

## 3 Entscheiden

In diesem Projekt wollen wir ein Programm mit GUI erstellen, mit dem man Hausaufgaben und Prüfungen mit Datum einschreiben kann.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |29.09.2023|Pascal Oestrich| 30' | 30' |
| 2.A  |29.09.2023|Pascal Oestrich| 30' | 10' |
| 3.A  |27.10.2023|Timo Goedertier| 30' | 45' |
| 4.A  |27.10.2023|Pascal Oestrich| 15' | 20' |
| 5.A  |03.11.2023|Timo Goedertier| 15' | 10' |
| 5.B  |03.11.2023|Timo Goedertier| 15' | 10' |
| 6.A  |03.11.2023|Pascal Oestrich| 60' | 25' |
| 6.B  |03.11.2023|Timo Goedertier| 120' | 30' |

## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |    03.11.2023   |    OK      |  Pascal Oestrich      |
| 2.1  |   03.11.2023    |    OK      |     Pascal Oestrich     |
| 3.1  |    03.11.2023   |    OK      |     Pascal Oestrich     |
| 4.1  |   03.11.2023    |    OK      |    Pascal Oestrich      |
| 6.1  |   03.11.2023    |     OK     |    Pascal Oestrich      |

Die Testfälle weisen keinen Fehler auf, alles läuft opitaml.

## Portfolio

Timo Goedertier (Portfolio): https://portfolio.bbbaden.ch/user/t-goedertier-inf22/school-o-gramm-in-c-mit-wpf

Pascal Oestrich (Portfolio): https://portfolio.bbbaden.ch/user/p-oestrich-inf22/modul-1301
