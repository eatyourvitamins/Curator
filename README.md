# Curator

1) Compiling / Running Curator.

 Depending where you are (either in visual studio or have the actual file) you can hit the start button to compile 
 and run the application -- Alternatively, you can double click the executable file if you have it to simply start
 the application.

 2) Using Curator

 Apon first run, you will notice a series of buttons, Replace books, Identify Areas, Find call numbers, Achievements
 and finally the exit button. Identify Areas and Find Call Numbers have been disabled for this build of the application
 as they are not yet required.

 Replace Books

 This button will take you to the main functionality of the Curator where you will be presented with 10 buttons that 
 have their own respective random call number generated for them -- you will need to click the buttons in order from
 smallest to largest in order to progress.

 If you happen to click a button and think that you have made a mistake or have seen a number that is smaller, the
 undo button will reverse your last action -- this is repeatable so you can undo as much as you like.

 If you are happy with your selection you may hit the finished button and the application will determine whether or
 not you have correctly re-ordered the call numbers in ascending order. If the order is not correct, a alert window 
 will appear informing you of this, after the window is dismissed, you will begin again from 0 as showing in the 
 count and progress bar.  

 If you have successfully re-ordered the call numbers from smallest to greatest, the application will analyse how 
 long it took you and determine which exact achievement(s) you will be recieveing.

 An achievement will always be recieved upon successful completion of the re-ordering as completion is a valid 
 achievement.

 NOTE: Duplicate achievements are not awarded -- this means that if you have previously gotten an achievement
 i.e. completeing the sorting of the call numbers, it will not be reawarded. Only new achievements will be
 awarded.

 Identify Areas

 This button will take you to the secondary function of the application where you are initially given four top-level
 call numbers in one column and seven possible definitions for those call numbers in the second column -- obviously
 only four will be correct.

 There are four boxes below the columns that will allow you to submit your answers, these boxes will only accept values
 from one (1) to seven (7). If your answers are incorrect -- all answers need to be correct for you to be able to move
 on -- the application will inform you that your answers are incorrect and clear the fields for you to retry. If your 
 answers are correct, you will move onto to a success screen and if you are completing this task for the first time, 
 will be awarded with an achievement for the successful completion of the task.

 This screen will allow you to return to the main menu if you wish, or else you are able to do the task again by hitting
 the 'go again' button. 

 NOTE: Consecutive runs of the Identify Areas task will alternate column A and column B. To elaborate, the first run of
 identifying areas will present four top-level call numbers in the left column and their possible definitions in the right
 column. Apon completing the task successfully and hitting the 'go again' button, the positions now alternate and the left
 column now has four defintions that need to be matched with their respective call number in the right column.

 Achievements

 Achievements can be accessed from the main menu by clicking the Achievements button. This will show you one of
 two things. An empty achievement list (for a first time user who has never attempted to sort the call 
 numbers) or the achievements you have earned by sorting the call numbers in a timely manner.

 An achievement was also added for successfully matching call numbers with their defintions in the Identify Areas task.

 NOTE: These reset apon ever re-launch of the application.

 Find Call Numbers

 Find call numbers is the latest addition to the application and will be the final feature of Curator. Upon launching 
 Find call numbers the user will be greeted with 4 main segments. The first, will be a third level call number that 
 belongs somewhere in the system, it is the user's job to try and decipher where exactly this number has to go, this is 
 where the second panel comes into play, the user will click any of the four buttons that are visible, only one of them 
 is correct. Upon selecting the correct button the user will need to move on to the third panel of the window, the buttons 
 are now disabled so a user cannot change their mind and return with a different answer, all answers are final as will be 
 explained a bit later. A listbox will populate with all of the second level call numbers from the button that the user has 
 clicked in the step prior, the user will need to select the correct second level call number in order to try and find the 
 last answer. If the user selects the correct second level call number, the selected listbox will become disabled and the final 
 listbox will become enabled and populated with all of the third level call numbers relevant to the choice made in the previous 
 selection. If the user selects the correct answer for the final listbox, they will be awared with an achievement for first time 
 successful completion and taken to a screen where they are able to make the choice of going again or returning to the main menu.

 NOTE: As previously stated, all selections are final and if a user selects so much as a single option that is incorrect, their 
 attempt will come to an end and they will be greeted with a screen that informs them that an incorrect selection has been made 
 and that their attempt is over. The user can either return to the main menu or try to find a new call number again.

 Call numbers are stored in a text file and are read by Curator whenever it starts. This is not a super hard-coded file as it is
 placed in a root directory for the application to recognize it on every run, there is no need to change any strings in the 
 source code.

 Exit

 Exits the application.
