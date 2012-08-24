using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectEuler.Problems;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectEuler {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadProblems();
        }

        private List<ProblemInfo> _problems;

        public void LoadProblems() {
            var problems = new List<ProblemInfo>();
            var solverTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(ProblemSolverBase));
            var solvers = solverTypes
                .Select(t => Activator.CreateInstance(t))
                .Cast<ProblemSolverBase>()
                .OrderBy(p => p.ProblemNumber)
                .ToList();
            problems.Add(new ProblemInfo() { Id = 0, Description = "Please choose a problem to solve..." });
            problems.AddRange(solvers.Select(x => new ProblemInfo() { Id = x.ProblemNumber, Description = x.ProblemTitle, Solver = x }));
            _problems = problems;

            cmbProblems.DataSource = problems;
            cmbProblems.DisplayMember = "Description";
        }

        private class ProblemInfo {
            public int Id { get; set; }
            public string Description { get; set; }
            public ProblemSolverBase Solver { get; set; }
        }

        private void cmbProblems_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbProblems.SelectedItem != null) {
                var problemInfo = cmbProblems.SelectedItem as ProblemInfo;
                if (problemInfo != null && problemInfo.Id > 0) {
                    txtSolution.Text = "WORKING...";
                    txtSolution.SelectionStart = 0;
                    cmbProblems.Enabled = false;
                    new Task(() => {
                        string text = problemInfo.Solver.Solve();
                        Action a = () => {
                            txtSolution.Text = problemInfo.Solver.Solve();
                            txtSolution.SelectionStart = txtSolution.Text.Length;
                            cmbProblems.Enabled = true;
                        };
                        Invoke(a);
                    }).Start();
                }
            }
        }
    }
}
