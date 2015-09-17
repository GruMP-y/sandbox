package com.example.vans.activitywithfragment;

import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

/**
 * A placeholder fragment containing a simple view.
 */
public class MainActivityFragment extends Fragment {

    public MainActivityFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_main, container, false);
    }

    public void addToList(String item) {
        TextView listView = (TextView) getActivity().findViewById(R.id.list_view);
        //listView.append(item + " " + listView.getLineCount() + "\n");
        listView.append(item + "\n");
    }

    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        IntentResult scanResult = IntentIntegrator.parseActivityResult(requestCode, resultCode, intent);
        if (scanResult != null) {
            // handle scan result
            String display;
            display = "Format: " + scanResult.getFormatName() + "\n";
            display = display + "Barcode Number:" + scanResult.getContents() + "\n";
            addToList(display);
        }
    }
}
