import os
import glob
import re
import pandas as pd # pip install pandas
import shutil 
from PyPDF2 import PdfReader # pip install PyPDF2

# uncomment the line below if you are using a csv file
# bad_schools = pd.read_csv('/path/to/bad_schools.csv')['School Name'].tolist()
# name is the column name in the xlsx file. Column name should be the A1,B1,C1,... cell. Else, you must include a delimiter.
bad_schools = pd.read_excel('C:/Users/Administrator/Desktop/console/filter_resume/book1.xlsx', engine='openpyxl')['Name'].tolist()

# path to the folder containing the resumes
resume_files = glob.glob("C:/Users/Administrator/Desktop/console/filter_resume/*.pdf")

# dir to store the matched and unmatched resumes
match_folder = "C:/Users/Administrator/Desktop/console/filter_resume/Match"
unmatch_folder = "C:/Users/Administrator/Desktop/console/filter_resume/Unmatch"

# Create the folders if they don't exist
os.makedirs(match_folder, exist_ok=True)
os.makedirs(unmatch_folder, exist_ok=True)

for resume_file in resume_files:
    with open(resume_file, 'rb') as file:
        pdf = PdfReader(file)
        resume = ""
        for page in range(len(pdf.pages)):
            resume += pdf.pages[page].extract_text()

    # uncomment if you prefer edit in code instead read from file
    # keywords = ["ruby"]
    with open('C:/Users/Administrator/Desktop/console/filter_resume/keywords.txt', 'r') as file:
        keywords = [line.strip() for line in file.readlines()]     

    if all(re.search(keyword, resume, re.IGNORECASE) for keyword in keywords):
        if not any(bad_school in resume for bad_school in bad_schools):
            # print("Match:", resume_file)
            shutil.move(resume_file, match_folder)
    else:
        shutil.move(resume_file, unmatch_folder)

# You can pass input line as you want
# below for open file dialog to select the folder
    # import tkinter as tk
    # from tkinter import filedialog

    # root = tk.Tk()
    # root.withdraw()  
    # selected_path = filedialog.askdirectory()
    # print("Selected path:", selected_path)  