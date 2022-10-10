using UnityEngine;

public delegate void StarClickDelegate(StarSystem star);

public class UIManager : MonoBehaviour
{
    [SerializeField] MainHUD mainHUD;
    [SerializeField] SelectionHUD selectionHUD;
    [SerializeField] StarViewer starViewer;

    public StarSystem selectedStar;

    public void OnStarClicked(StarSystem star) 
    {
        if (selectedStar != null) 
        {
            starViewer.Clear(selectedStar);

            if (selectedStar == star)
            {
                mainHUD.Close();
                selectionHUD.Close();
                starViewer.Clear(selectedStar);
                selectedStar = null;
                return;
            }
        }

        selectedStar = star;
        mainHUD.Open(star);
        selectionHUD.Open(star);
        starViewer.ShowSystem(star);
    }

    public void OnNothingClicked()
    {
        mainHUD.Close();
        selectionHUD.Close();
        starViewer.Clear(selectedStar);
        selectedStar = null;
    }
}
